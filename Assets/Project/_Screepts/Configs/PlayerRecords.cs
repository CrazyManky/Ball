using System.Collections.Generic;
using UnityEngine;

namespace Project._Screepts.Configs
{
    [CreateAssetMenu(fileName = "PlayerRecords", menuName = "ScriptableObjects/PlayerRecords")]
    public class PlayerRecords : ScriptableObject
    {
        [SerializeField] private List<int> _records;


        public void AddRecord(int record) => _records.Add(record);


        public List<int> GetSortedItems()
        {
            _records.Sort();

            List<int> sortedRecords = new List<int>();

            for (int i = 0; i < Mathf.Min(8, _records.Count); i++)
            {
                sortedRecords.Add(_records[i]);
            }

            return sortedRecords;
        }
    }
}