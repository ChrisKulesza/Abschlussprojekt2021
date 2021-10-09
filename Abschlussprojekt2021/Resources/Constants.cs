namespace Abschlussprojekt2021.Resources
{
    public static class Constants
    {
        // Author
        public static string Author = "Christian Kulesza";

        // Roles
        public static string RoleAdmin = "Admin";
        public static string RoleEditor = "Editor";

        // Icons
        public static string IconPlus = "fas fa-plus";
        public static string IconDelete = "fas fa-trash-alt";
        public static string IconEdit = "fas fa-edit";
        public static string IconCopy = "fas fa-copy";
        public static string IconDetails = "fas fa-file-contract";

        // Buttons
        public static string BtnSave = "Save";
        public static string BtnCancel = "Cancel";
        public static string BtnDelete = "Delete";

        // Strings
        public static string TxtLogoutInfo = "Sie werden ausgeloggt und auf die Landingpage weitergeleitet.";
        public static string TxtDeleteConfirmation = "Wollen Sie den Eintrag wirklich löschen?";
        // DSGVO
        public static string TextDSGVOCheckbox = "Sie erklären sich damit einverstanden, dass Ihre Daten im Rahmen zur Bearbeitung Ihres Anliegens verwendet werden. Informationen und Widerrufshinweise finden Sie in der Datenschutzerklärung.";

        // Error Messages
        // {0} = name of the property
        // {1} = maximum length
        // {2} = minimum length
        public const string errorMessageStringLength = "The {0} must be at least {2} and a maximum of {1} characters long.";
    }
}
