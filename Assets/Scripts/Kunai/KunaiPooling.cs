using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiPooling : MonoBehaviour
{
    public static KunaiPooling Instance;
    private List<GameObject> _kunaiObjects = new List<GameObject>();
    public int amountKunai;
    [SerializeField] private GameObject _kunaiPrefab;
    public Transform firePoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        for (int i = 0; i < amountKunai; i++)
        {
            GameObject kunai = Instantiate(_kunaiPrefab, firePoint);
            kunai.SetActive(false);
            _kunaiObjects.Add(kunai);
        }
    }
    public GameObject GetPooledKunai()
    {
        for (int i = 0; i < _kunaiObjects.Count; i++)
        {
            if (!_kunaiObjects[i].activeInHierarchy)
            {
                return _kunaiObjects[i];
            }
        }
        return null;
    }
}
