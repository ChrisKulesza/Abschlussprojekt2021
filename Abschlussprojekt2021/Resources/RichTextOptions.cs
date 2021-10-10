using System.Collections.Generic;

namespace Abschlussprojekt2021.Resources
{
    public class RichTextOptions
    {
        public List<string> Options { get; private set; }

        /// <summary>
        /// Provides the RTE options. The scope is minimal in the context of the project.
        /// </summary>
        /// <returns>Returns a list of options for the Syncfusion UI component RTE.</returns>
        public List<string> GetRTEOptionsMinimumScope()
        {
            Options = new List<string>()
            {
                "Bold", "Italic", "FontName", "FontSize", "FontColor", "|",
                "OrderedList", "UnorderedList", "|",
                "Formats", "Alignments", "Outdent", "Indent", "|",
                "CreateLink", "|"
                // "Undo", "Redo"
            };

            return Options;
        }

        /// <summary>
        /// Provides the RTE options. The scope is maximum in the context of the project.
        /// </summary>
        /// <returns>Returns a list of options for the Syncfusion UI component RTE.</returns>
        public List<string> GetRTEOptionsMaximumScope()
        {
            Options = new List<string>()
            {
                "Bold", "Italic", "Underline", "StrikeThrough",
                "FontName", "FontSize", "FontColor", "BackgroundColor", "LowerCase", "UpperCase", "|",
                "Formats", "Alignments", "OrderedList", "UnorderedList",
                "Outdent", "Indent", "|",
                "CreateLink", "Open", "Image", "CreateTable", "|",
                "ClearFormat", "Print",
                "SourceCode", "FullScreen", "|",
                "Undo", "Redo"
            };

            return Options;
        }
    }
}
