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
        private int ratingsCurrentRowIndex;
        private int ratingAgenciesRowIndex;
        private Rating currentRow;
        private RatingAgency currentRatingAgency;

        public Ratings()
        {
            InitializeComponent();
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            tableUtility.CreateTable(Rating.GetDefaultValue());
            tableUtility.CreateTable(RatingAgency.GetDefaultValue());
            ratingAgenciesRowIndex = 0;
            LoadRatingAgencies();
        }

        private void LoadRatingAgencies()
        {
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            List<RatingAgency> agencyList = tableUtility.ConvertRangesToObjects<RatingAgency>(tableUtility.ReadAllRows(RatingAgency.GetDefaultValue()));
            foreach (RatingAgency agency in agencyList)
            {
                ratingAgencyBindingSource.Add(agency);
            }
        }

        public void OnSubmit(List<string> passedValue, string reference)
        {
            dataGridViewRatingAgencies.ClearSelection();
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            RatingAgency ratingAgency = new RatingAgency(passedValue[0]);
            tableUtility.InsertTableRow(ratingAgency);
            int index = ratingAgencyBindingSource.Add(ratingAgency);
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
                RatingNumericValue = oldRating.RatingNumericValue
            };
            return newRating;
        }

        private void RowValidatedRatings(object sender, DataGridViewCellEventArgs e)
        {
            if (currentRatingAgency == null)
            {
                return;
            }
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
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

            if (!currentRow.RatingCode.Equals(newRating.RatingCode))
            {
                TableUpdateWrapper update = new TableUpdateWrapper(currentRow.Index, "RatingCode", newRating.RatingCode);
                tableUtility.UpdateTableRow(currentRow, update);
            }

            if (currentRow.RatingNumericValue != newRating.RatingNumericValue)
            {
                TableUpdateWrapper update = new TableUpdateWrapper(currentRow.Index, "RatingNumericValue", newRating.RatingNumericValue.ToString());
                tableUtility.UpdateTableRow(currentRow, update);
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
                TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
                tableUtility.DeleteTableRow(currentRow);
                dataGridViewRatingCodes.Rows.RemoveAt(ratingsCurrentRowIndex);
            }
        }

        private void DeleteRatingAgencyClick(object sender, EventArgs e)
        {
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            RatingAgency ratingAgencyToDelete = dataGridViewRatingAgencies.Rows[ratingAgenciesRowIndex].DataBoundItem as RatingAgency;
            List<Rating> ratingsToDelete = tableUtility.ConvertRangesToObjects<Rating>(tableUtility.ReadTableRow(Rating.GetDefaultValue().GetTableName(), new Dictionary<string, string>
            {
                {"Agency", ratingAgencyToDelete.GetIndex().ToString() }
            }, QueryOperator.OR));
            foreach (Rating rating in ratingsToDelete)
            {
                tableUtility.DeleteTableRow(rating);
            }
            tableUtility.DeleteTableRow(ratingAgencyToDelete);
            ratingAgencyBindingSource.RemoveAt(ratingAgenciesRowIndex);
            LoadRatings(ratingAgenciesRowIndex);
            if (ratingAgencyBindingSource.Count == 0)
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
            currentRatingAgency = ratingAgencyBindingSource[ratingAgenciesRowIndex] as RatingAgency;
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
                ratingBindingSource.Clear();
                return;
            }
            ratingBindingSource.Clear();
            if (currentRatingAgency == null)
            {
                return;
            }
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);

            List<Range> agencyRanges = tableUtility.ReadTableRow(Rating.GetDefaultValue().GetTableName(), new Dictionary<string, string>
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
                ratingBindingSource.Add(rating);
            }
        }
    }
}
