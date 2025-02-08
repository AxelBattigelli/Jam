using UnityEngine;

public class Oasis_Opacity : MonoBehaviour
{
    public Transform player;  // Le joueur ou la cam�ra
    public float fadeDistance = 50f;  // Distance � laquelle commence l'effet
    public float maxFadeDistance = 30f;  // Distance � laquelle l'objet dispara�t compl�tement
    private Renderer rend;  // Le rendu de l'objet (le tronc)
    private Material mat;  // Le mat�riau de l'objet

    void Start()
    {
        rend = GetComponent<Renderer>();  // R�cup�rer le Renderer de l'objet
        mat = rend.material;  // R�cup�rer le mat�riau de l'objet
    }

    void Update()
    {
        // Calculer la distance entre le joueur et l'objet (le tronc)
        float distance = Vector3.Distance(player.position, transform.position);

        // Utiliser Mathf.InverseLerp pour obtenir une valeur de 0 � 1 en fonction de la distance
        // Si la distance est inf�rieure � fadeDistance, alpha sera �gal � 1 (compl�tement visible)
        // Si la distance est sup�rieure � maxFadeDistance, alpha sera �gal � 0 (compl�tement invisible)
        float alpha = Mathf.InverseLerp(fadeDistance, maxFadeDistance, distance);

        // Inverser l'alpha pour que l'opacit� commence � 1 (visible) et diminue � 0 (invisible)
        alpha = 1 - alpha;

        // Modifier l'opacit� du mat�riau
        Color color = mat.color;
        color.a = alpha;  // Appliquer l'opacit� calcul�e
        mat.color = color;
    }
}
