using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<ResourceTypeSO, int> resourcesAmountDictionary;

    private void Awake() 
    {
        resourcesAmountDictionary  = new Dictionary<ResourceTypeSO, int>();
        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        foreach (ResourceTypeSO resourceType in resourceTypeList.list) 
        {
            resourcesAmountDictionary[resourceType] = 0;
        }

        TestLogResourceAmountDictionary();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.T)) 
        {
            ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
            AddResource(resourceTypeList.list[0], 2);
            TestLogResourceAmountDictionary();
        }
    }

    private void TestLogResourceAmountDictionary() 
    {
        foreach (ResourceTypeSO resourceType in resourcesAmountDictionary.Keys) 
        {
            Debug.Log(resourceType.nameString + ": " + resourcesAmountDictionary[resourceType]);
        }
    }

    public void AddResource(ResourceTypeSO resourceType, int amount) 
    {
        resourcesAmountDictionary[resourceType] += amount;
    }
}
