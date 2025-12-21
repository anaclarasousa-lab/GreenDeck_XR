using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject Photos;
    public GameObject Monstera;
    public GameObject Violeta;
    public GameObject Tulipan;
    public GameObject Amarilis;




    public void SpawnPhotos()
    {
        Instantiate(Photos);
    }
        public void SpawnMonstera()
    {
        Instantiate(Monstera);
    }
        public void SpawnVioleta()
    {
        Instantiate(Violeta);
    }
        public void SpawnTulipan()
    {
        Instantiate(Tulipan);
    }
        public void SpawnAmarilis()
    {
        Instantiate(Amarilis);
    }
}
