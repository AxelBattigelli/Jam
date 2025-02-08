using UnityEngine;

public class Oasis_Opacity : MonoBehaviour
{
    public Transform player;  // Le joueur ou la caméra
    public float fadeDistance = 50f;  // Distance à laquelle commence l'effet
    public float maxFadeDistance = 30f;  // Distance à laquelle l'objet disparaît complètement
    private Renderer rend;  // Le rendu de l'objet (le tronc)
    private Material mat;  // Le matériau de l'objet

    void Start()
    {
        rend = GetComponent<Renderer>();  // Récupérer le Renderer de l'objet
        mat = rend.material;  // Récupérer le matériau de l'objet
    }

    void Update()
    {
        // Calculer la distance entre le joueur et l'objet (le tronc)
        float distance = Vector3.Distance(player.position, transform.position);

        // Utiliser Mathf.InverseLerp pour obtenir une valeur de 0 à 1 en fonction de la distance
        // Si la distance est inférieure à fadeDistance, alpha sera égal à 1 (complètement visible)
        // Si la distance est supérieure à maxFadeDistance, alpha sera égal à 0 (complètement invisible)
        float alpha = Mathf.InverseLerp(fadeDistance, maxFadeDistance, distance);

        // Inverser l'alpha pour que l'opacité commence à 1 (visible) et diminue à 0 (invisible)
        alpha = 1 - alpha;

        // Modifier l'opacité du matériau
        Color color = mat.color;
        color.a = alpha;  // Appliquer l'opacité calculée
        mat.color = color;
    }
}
