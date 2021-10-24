namespace Domain.Models
{
    /// <summary>
    /// Model of a syncfusion button for a modal window.
    /// </summary>
    public class Button
    {
        /// <value>Text value of the button.</value>
        public string content { get; set; }

        /// <value>Determination of whether the button is a first-order button.</value>
        public bool isPrimary { get; set; }

        /// <value>Css class of the created button.</value>
        public string cssClass { get; set; }
    }
}
