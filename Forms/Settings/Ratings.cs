using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Forms.Settings
{
    public partial class Ratings : UserControl, IPassedForm
    {
        private DataGridView dataGridViewRatingAgencies;
        private DataGridView dataGridViewRatingCodes;
        private int ratingsCurrentRowIndex;
        private int ratingAgenciesRowIndex;
        private Rating currentRow;
        private RatingAgency currentRatingAgency;

        public Ratings()
        {
            InitializeComponent();
            InitializeCustomComponents();
            TableUtility tableUtility = new TableUtility();
            tableUtility.CreateTable(Rating.GetDefaultValue());
            tableUtility.CreateTable(RatingAgency.GetDefaultValue());
            ratingAgenciesRowIndex = 0;
            LoadRatingAgencies();
        }

        private void InitializeCustomComponents()
        {
            dataGridViewRatingAgencies = FormUtility.CreateDataGridView(typeof(RatingAgency), 55, 308, 600, 400);
            dataGridViewRatingCodes = FormUtility.CreateDataGridView(typeof(Rating), 650, 308, 600, 600);
            dataGridViewRatingCodes.AllowUserToAddRows = true;
            ToolStripMenuItem deleteAgency = FormUtility.CreateContextMenuItem("Löschen", DeleteRatingAgencyClick);
            FormUtility.AddContextMenu(dataGridViewRatingAgencies, deleteAgency);
            FormUtility.AddDataGridViewEditingHandlers(dataGridViewRatingCodes, CatchCurrentRowState, RowValidatedRatings, DeleteRow);
            dataGridViewRatingAgencies.MouseClick += (sender, e) =>
            {
                ClickRatingAgencies(sender, e);
            };
            dataGridViewRatingAgencies.MouseDown += (sender, e) =>
            {
                DataGridRatingAgenciesMouseDown(sender, e);
            };
            Controls.Add(dataGridViewRatingAgencies);
            Controls.Add(dataGridViewRatingCodes);
        }

        private void LoadRatingAgencies()
        {
            TableUtility tableUtility = new TableUtility();
            List<RatingAgency> agencyList = tableUtility.ConvertRangesToObjects<RatingAgency>(tableUtility.ReadAllRows(RatingAgency.GetDefaultValue()));
            foreach (RatingAgency agency in agencyList)
            {
                FormUtility.GetBindingSource(dataGridViewRatingAgencies).Add(agency);
            }
        }

        public void OnSubmit(List<string> passedValue, string reference)
        {
            dataGridViewRatingAgencies.ClearSelection();
            TableUtility tableUtility = new TableUtility();
            RatingAgency ratingAgency = new RatingAgency(passedValue[0]);
            tableUtility.InsertTableRow(ratingAgency);
            int index = FormUtility.GetBindingSource(dataGridViewRatingAgencies).Add(ratingAgency);
            dataGridViewRatingAgencies.Rows[index].Selected = true;
            currentRatingAgency = ratingAgency;
            ratingAgenciesRowIndex = index;
            LoadRatings(ratingAgenciesRowIndex);
        }

        private void ButtonAddRatingAgency_Click(object sender, EventArgs e)
        {
            _ = new OneAttributeForm(this, "Rating-Agentur", "rating_agency")
            {
                Visible = true
            };
        }

        private Rating CopyRating(Rating oldRating)
        {
            if (oldRating == null)
            {
                return null;
            }
            Rating newRating = new Rating
            {
                Index = oldRating.Index,
                RatingCode = oldRating.RatingCode,
                RatingNumericValue = oldRating.RatingNumericValue,
                Agency = oldRating.Agency
            };
            return newRating;
        }

        private void RowValidatedRatings(object sender, DataGridViewCellEventArgs e)
        {
            if (currentRatingAgency == null)
            {
                return;
            }
            TableUtility tableUtility = new TableUtility();
            Rating newRating = dataGridViewRatingCodes.Rows[e.RowIndex].DataBoundItem as Rating;
            if (newRating == null)
            {
                return;
            }
            newRating.Agency = currentRatingAgency;
            if (newRating.Index == 0)
            {
                tableUtility.InsertTableRow(newRating);
                return;
            }
            if (currentRow == null)
            {
                return;
            }

            if (!currentRow.Equals(newRating))
            {
                tableUtility.MergeTableRow(newRating);
            }
        }

        private void CatchCurrentRowState(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
            {
                if (currentRatingAgency == null)
                {
                    dataGridViewRatingCodes.ClearSelection();
                    dataGridViewRatingCodes.CancelEdit();
                    return;
                }

                if (ratingsCurrentRowIndex == e.Cell.RowIndex)
                {
                    return;
                }
                ratingsCurrentRowIndex = e.Cell.RowIndex;
                currentRow = CopyRating(dataGridViewRatingCodes.Rows[ratingsCurrentRowIndex].DataBoundItem as Rating);
            }
        }

        private void DeleteRow(object sender, KeyEventArgs e)
        {
            if (currentRow == null)
            {
                return;
            }

            if (e.KeyCode == Keys.Delete)
            {
                TableUtility tableUtility = new TableUtility();
                tableUtility.DeleteTableRow(currentRow);
                dataGridViewRatingCodes.Rows.RemoveAt(ratingsCurrentRowIndex);
            }
        }

        private void DeleteRatingAgencyClick(object sender, EventArgs e)
        {
            TableUtility tableUtility = new TableUtility();
            RatingAgency ratingAgencyToDelete = dataGridViewRatingAgencies.Rows[ratingAgenciesRowIndex].DataBoundItem as RatingAgency;
            List<Rating> ratingsToDelete = tableUtility.ConvertRangesToObjects<Rating>(tableUtility.ReadTableRow(Rating.GetDefaultValue(), new Dictionary<string, string>
            {
                {"Agency", ratingAgencyToDelete.GetIndex().ToString() }
            }, QueryOperator.OR));
            foreach (Rating rating in ratingsToDelete)
            {
                tableUtility.DeleteTableRow(rating);
            }
            tableUtility.DeleteTableRow(ratingAgencyToDelete);
            FormUtility.GetBindingSource(dataGridViewRatingAgencies).RemoveAt(ratingAgenciesRowIndex);
            LoadRatings(ratingAgenciesRowIndex);
            if (FormUtility.GetBindingSource(dataGridViewRatingAgencies).Count == 0)
            {
                currentRatingAgency = null;
            }
        }

        private void DataGridRatingAgenciesMouseDown(object sender, MouseEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            ratingAgenciesRowIndex = FormUtility.DataGridViewMouseDownContextMenu(dataGridView, e);
            if (ratingAgenciesRowIndex < 0)
            {
                return;
            }
            currentRatingAgency = FormUtility.GetBindingSource(dataGridViewRatingAgencies)[ratingAgenciesRowIndex] as RatingAgency;
        }

        private void ClickRatingAgencies(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                LoadRatings(ratingAgenciesRowIndex);
            }
        }

        private void LoadRatings(int index)
        {
            if (index < 0)
            {
                FormUtility.GetBindingSource(dataGridViewRatingCodes).Clear();
                return;
            }
            FormUtility.GetBindingSource(dataGridViewRatingCodes).Clear();
            if (currentRatingAgency == null)
            {
                return;
            }
            TableUtility tableUtility = new TableUtility();

            List<Range> agencyRanges = tableUtility.ReadTableRow(Rating.GetDefaultValue(), new Dictionary<string, string>
            {
                {"Agency", currentRatingAgency.GetIndex().ToString() }
            }, QueryOperator.OR);

            if (agencyRanges.Count == 0)
            {
                return;
            }

            List<Rating> ratings = tableUtility.ConvertRangesToObjects<Rating>(agencyRanges);
            foreach (Rating rating in ratings)
            {
                FormUtility.GetBindingSource(dataGridViewRatingCodes).Add(rating);
            }
        }
    }
}
