# entity-framework
## migration
https://docs.microsoft.com/fr-fr/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application

## Console du gestionnaire de package
Dans le menu **Outils**, sélectionnez **Gestionnaire de package NuGet** > **Console du gestionnaire de package**
À l’invite `PM>`, entrez les commandes suivantes :

### ajouter une migration
```
add-migration <name>
```

### Mettre à jour la bdd avec une migration
```
Update-Database
```
#### Mettre à jour une migration spécifique
```
update-database -target <name>
```