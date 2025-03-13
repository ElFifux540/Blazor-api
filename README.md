# Documentation du Projet Blazor - FifuxServer Sleep

## Description

Ce projet est une interface Blazor permettant de contrôler un ESP32 en envoyant des commandes de temps de veille via une API. Il prend en charge la gestion des favoris et la gestion des mises à jour échouées.

---

## Installation

1. **Clone du dépôt** :
   ```bash
   git clone https://github.com/votre-repo/blazor-api.git
   cd blazor-api
   ```

2. **Installation des dépendances** :
   ```bash
   dotnet restore
   ```

3. **Exécuter le projet** :
   ```bash
   dotnet run
   ```

4. **Accès à l'interface** :
   Ouvrir `http://localhost:5000` dans votre navigateur.

---

## Fonctionnalités

- Affichage des temps de veille disponibles.
- Sélection du temps de veille.
- Gestion d’un favori mémorisé en local.
- Gestion des mises à jour échouées avec une tentative automatique toutes les 30 secondes.

---

## Scénarios de tests

### Tests d'API
```csharp
// Inclut des tests avec Moq et Xunit pour simuler l'API et les réponses HTTP
```

### Tests de LocalStorage
```csharp
// Tests pour vérifier la bonne sauvegarde et récupération des valeurs dans le stockage local
```

---

## Améliorations possibles

- Support de plusieurs favoris
- Gestion des erreurs plus détaillée
- Interface plus ergonomique
