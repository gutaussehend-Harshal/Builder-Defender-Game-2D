using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<ResourceTypeSO, int> resourcesAmountDictionary;

    private void Awake() 
    {
        resourcesAmountDictionary  = new Dictionary<ResourceTypeSO, int>();
        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeSO>(typeof(ResourceTypeListSO).Name);

        foreach (ResourceTypeSo resourceType in resourceTypeList.list) 
        {
            resourceAmountDictionary[resourceType] = 0;
        }

        TestLogResourceAmountDictionary();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(keyCode.T)) 
        {
            ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
            AddResource(resourceTypeList.list[0], 2);
            TestLogResourceAmountDictionary();
        }
    }

    private void TestLogResourceAmountDictionary() 
    {
        foreach (ResourceTypeSo resourceType in resourcesAmountDictionary.Keys) 
        {
            Debug.Log(resourceType.nameString + ": " + resourcesAmountDictionary[resourceType]);
        }
    }

    public void AddResource(ResourceTypeSo resourceType, int amount) 
    {
        resourcesAmountDictionary[resourceType] += amount;
    }
}
