using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Persistence;

namespace Watchdog.Forms
{
    public partial class Ratings : UserControl, PassedForm
    {
        private int ratingsCurrentRowIndex;
        private Rating currentRow;
        private RatingAgency currentRatingAgency;

        public Ratings()
        {
            InitializeComponent();
            LoadRatingAgencies();
        }

        private void LoadRatingAgencies()
        {
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            List<RatingAgency> agencyList = tableUtility.ConvertRangesToObjects<RatingAgency>(tableUtility.ReadAllRows(RatingAgency.GetDefaultValue().GetTableName()));
            foreach (RatingAgency agency in agencyList)
            {
                ratingAgencyBindingSource.Add(agency);
            }
        }

        public void OnSubmit(List<string> passedValue, string reference)
        {
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            RatingAgency ratingAgency = new RatingAgency(passedValue[0]);
            tableUtility.CreateMissingTable(RatingAgency.GetDefaultValue());
            tableUtility.InsertTableRow(ratingAgency, new List<string>
            {
                passedValue[0]
            });
            ratingAgencyBindingSource.Add(ratingAgency);

        }

        private void ButtonAddRatingAgency_Click(object sender, EventArgs e)
        {
            _ = new OneAttributeForm(this, "Rating-Agentur", "rating_agency")
            {
                Visible = true
            };
        }

        private void SelectionChangedLoadRatings(object sender, EventArgs e)
        {

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
            tableUtility.CreateMissingTable(Rating.GetDefaultValue());
            Rating newRating = dataGridViewRatingCodes.Rows[e.RowIndex].DataBoundItem as Rating;
            if (newRating == null)
            {
                return;
            }
            if (newRating.Index == 0)
            {
                tableUtility.InsertTableRow(newRating, new List<string>
                {
                    newRating.RatingCode,
                    newRating.RatingNumericValue.ToString(),
                    currentRatingAgency.Index.ToString()
                });
                return;
            }

            if (!currentRow.RatingCode.Equals(newRating.RatingCode))
            {
                TableUpdateWrapper update = new TableUpdateWrapper(currentRow.Index, "rating_code", newRating.RatingCode);
                tableUtility.UpdateTableRow(currentRow, update);
            }

            if (currentRow.RatingNumericValue != newRating.RatingNumericValue)
            {
                TableUpdateWrapper update = new TableUpdateWrapper(currentRow.Index, "numeric_value", newRating.RatingNumericValue.ToString());
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
                tableUtility.DeleteTableRow(currentRow, currentRow.GetIndex());
                dataGridViewRatingCodes.Rows.RemoveAt(ratingsCurrentRowIndex);
            }
        }

        private void AgencySelected(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            currentRatingAgency = dataGridViewRatingAgencies.Rows[e.Cell.RowIndex].DataBoundItem as RatingAgency;
        }
    }
}
