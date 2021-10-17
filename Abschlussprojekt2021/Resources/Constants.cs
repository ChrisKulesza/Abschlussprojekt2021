namespace Abschlussprojekt2021.Resources
{
    public static class Constants
    {
        // Author
        public const string Author = "Christian Kulesza";

        // Roles
        public const string RoleAdmin = "Admin";
        public const string RoleEditor = "Editor";

        // Icons
        public const string IconPlus = "fas fa-plus";
        public const string IconDelete = "fas fa-trash-alt";
        public const string IconEdit = "fas fa-edit";
        public const string IconCopy = "fas fa-copy";
        public const string IconDetails = "fas fa-file-contract";

        // Buttons
        public const string BtnSave = "Save";
        public const string BtnCancel = "Cancel";
        public const string BtnDelete = "Delete";

        // Strings
        public const string TxtLogoutInfo = "Sie werden ausgeloggt und auf die Landingpage weitergeleitet.";
        public const string TxtDeleteConfirmation = "Wollen Sie den Eintrag wirklich löschen?";
        // DSGVO
        public const string TextDSGVOCheckbox = "Sie erklären sich damit einverstanden, dass Ihre Daten im Rahmen zur Bearbeitung Ihres Anliegens verwendet werden. Informationen und Widerrufshinweise finden Sie in der Datenschutzerklärung.";

        // Error Messages
        // {0} = name of the property
        // {1} = maximum length
        // {2} = minimum length
        public const string errorMessageStringLength = "The {0} must be at least {2} and a maximum of {1} characters long.";
    }
}
