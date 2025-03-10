Pour réaliser le setup créer un projet 2D classique dans unity.

Au démarrage, créer le répertoire Scripts et Prefabs dans le Répertoire Assets.

Pour setup un simple script de spawn de cercle dans la scene, il faut tout d'abord ajouter un prefab d'objet de cercle dans la scene :
- faire clique droit dans la 'SampleScene' de 'Hierarchy' et ajouter un '2D Object'->'Sprites'->'Circle'.
- Drag and Drop ce Sample de cercle dans le répertoire Prefabs dans Assets.
- coder le script en C# à relier au GameObject à suivre.

```
using UnityEngine;

public class Simulation : MonoBehaviour
{
    public GameObject circlePrefab; // Reference to the Circle Prefab

    void Start()
    {
    }

    void SpawnCircle()
    {
        if (circlePrefab != null)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)); // Random position
            Instantiate(circlePrefab, spawnPosition, Quaternion.identity); // Spawn the circle
        }
        else
        {
            Debug.LogError("Circle Prefab is not assigned in the Inspector!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCircle(); // Call function to spawn a circle
        }
    }
}
```

- Créer un 'Empty' dans la 'SampleScene' et relier le script et le prefabs avec le bouton Add Component dans le menu Inspector a droite de l'écran.
- Lancer le script avec le bouton play et normalement un cercle devrait apparaitre aléatoirement a chaque press de la barre espace.