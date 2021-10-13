using System.Collections.Generic;

namespace Abschlussprojekt2021.Resources
{
    public class SyncfusionOptionsService
    {
        IEnumerable<string> _rteOptionsListMinimal = new List<string>()
        {
            "Bold", "Italic", "FontName", "FontSize", "FontColor", "|",
            "OrderedList", "UnorderedList", "|",
            "Formats", "Alignments", "Outdent", "Indent", "|",
            "CreateLink", "|"
            // "Undo", "Redo"
        };

        IEnumerable<string> _rteOptionsListMaximal = new List<string>()
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

        /// <summary>
        /// Provides the RTE options. The scope is minimal in the context of the project.
        /// </summary>
        /// <returns>Returns a list of options for the Syncfusion UI component RTE.</returns>
        public IEnumerable<string> RTEOptionsListMinimal()
        {
            return _rteOptionsListMinimal;
        }

        /// <summary>
        /// Provides the RTE options. The scope is maximum in the context of the project.
        /// </summary>
        /// <returns>Returns a list of options for the Syncfusion UI component RTE.</returns>
        public IEnumerable<string> RTEOptionsListMaximal()
        {
            return _rteOptionsListMaximal;
        }
    }
}
