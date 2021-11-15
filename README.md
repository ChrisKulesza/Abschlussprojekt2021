
# Abschlussprojekt2021
## Projektziel
Dieses Projekt stellt mein Abschlussprojekt dar, welches ich im Rahmen meiner Umschulung zum Fachinformatiker für 
Anwendungsentwicklung absolivieren muss. Das Projekt ist Teil der Prüfung.

## Thema des Projekt
Erstellung einer Razor Page, welche die Karriere Webseite eines Unternehmens darstellt. Die folgenden Akteure gibt es auf der Webseite:
- Besucher (nicht autorisiert)
  - bekommen die Stellenabzeigen in Form eines Data grid angezeigt
  - können über ein Icon zur Detailseite einer Stellenanzeige gelagen
  - Bewerbung auf die Stelle erfolgt dann über ein Formular auf der Detailseite (Noch nicht implementiert)
- Editor (autorisiert)
  - erstellen, bearbeiten, löschen von Stellenanzeigen
- Admin (autorisiert)
  - erstellen, bearbeiten, löschen von Stellenanzeigen
  - erstellen, bearbeiten, löschen von Nutzern

## Technologie
### Genutzte Frameworks
- Entity Framework
- Nutzerverwaltung mit Identity

### Third party librarys
- Syncfuion UI Components
  - Data grid
  - Rich text editor

### Design Pattern
- Repository Pattern
- Unit of Work Pattern
- Clean Architecture (Class Librarys)

### Services
- Seeding Data
- DTO (Data transfer object)

### Data binding
- Modelbinding
- AJAX Calls
  - to trigger handler methods via Syncfusion commands

```diff
+ Green
- Red
! Orange
@@ Pink @@
# Gray
```
