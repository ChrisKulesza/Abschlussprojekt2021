namespace Domain.Resources
{
    /// <summary>
    /// Provides all constants globally via dependency injection. It contains text 
    /// modules, prepopulating texts for input fields, button texts and error messages.
    /// </summary>
    public static class Constants
    {
        // Author
        public const string Author = "Christian Kulesza";

        // Navigation
        public const string navUserLandingPage = "Startseite";
        public const string navUserManagement = "Benutzerverwaltung";

        // Form data
        public const string formFirstName = "Vorname";
        public const string formLastName = "Nachname";
        public const string formLastVornameNachname = "Vorname Nachname";
        public const string formNameJobAd = "Bezeichnung der Stellenbeschreibung";
        public const string formEmail = "Email";
        public const string formRole = "Rolle";
        public const string formRegion = "Rolle";
        public const string formMainSkills = "Fähigkeiten";
        public const string formStartDate = "Start date";
        public const string formJobAdName = "Name der Stellenbeschreibung";
        public const string formDescription = "Beschreibung";
        public const string formMessage = "Nachricht";
        public const string formPassword = "Passwort";
        public const string formPasswordConfirm = "Passwort bestätigen";

        // Richtext Editor
        public const string rtePlaceholder = "Stellenbeschreibung bitte hier eingeben.";

        // Syncfusion Data grid
        public const string syncJobAdNew = "Neue Stelle anlegen";
        public const string syncUserNew = "Neuen Nutzer anlegen";
        public const string syncJobAd = "Offene Stelle";
        public const string syncFirstName = "Vorname";
        public const string syncLastName = "Nachname";
        public const string syncEmail = "Email";
        public const string syncRole = "Rolle";
        public const string syncDescription = "Beschreibung";
        public const string syncPosition = "Position";
        public const string syncMainSkills = "Fähigkeiten";
        public const string syncRegion = "Region";
        public const string syncStartDate = "Ausschreibedatum";

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
        public const string BtnRegister = "Register";

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
