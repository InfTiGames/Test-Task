using System.Linq;
using UnityEngine;

namespace SaveHandlers {

    public class SaveData : MonoBehaviour {

        private IDataSaver[] _dataSavers;

        private void Start() => _dataSavers = GetComponents<IDataSaver>().ToArray();

        public void Save() {
            foreach (IDataSaver saver in _dataSavers)
                saver.Save();
        }
    }
}