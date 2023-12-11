using TMPro;
using UnityEngine;

namespace Mono
{
    public class TowerCreator : MonoBehaviour
    {
        [SerializeField]
        public GameObject _cubePrefab;
        [SerializeField]
        public int _length;
        [SerializeField]
        public int _width;
        [SerializeField]
        public int _height;
        [SerializeField]
        public TextMeshProUGUI _cubeCounterText;

        void Start()
        {
            int cubeCount = 0;
            for (int h = 0; h < _height; h++)
            {
                for (int w = 0; w < _width; w++)
                {
                    for (int l = 0; l < _length; l++)
                    {
                        if (l != 0 && w != 0 && l != _length - 1 && w != _width - 1)
                        {
                            continue;
                        }

                        Instantiate(_cubePrefab, new Vector3(l, h + 0.5f, w), Quaternion.identity);
                        cubeCount++;
                    }
                }
            }
            _cubeCounterText.text = "Cube Count: " + cubeCount;
        }
    }
}

