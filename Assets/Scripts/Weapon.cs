using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject prefabricatedBullet;
    [SerializeField] private Transform tip;

    [ContextMenu("Fire")]
    public void FireInstance()
    {
        var newBullet = Instantiate(prefabricatedBullet,
            transform.position,
            transform.rotation);
        
        newBullet.Fire();
    }

    

}
