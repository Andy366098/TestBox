using System.Collections;
using TMPro;
using Unity.Entities;
using Unity.Physics;
using UnityEngine;

namespace ECS
{
    public class CubeCounterUIController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _cubeCounterText;

        private EntityQuery _query;
        private EntityManager _entityManager;

        private IEnumerator Start()
        {
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            // Wait a few frames until ECS world is loaded, then get player entity reference
            yield return new WaitForSeconds(0.2f);
            _query = _entityManager.CreateEntityQuery(typeof(PhysicsVelocity));
        }

        void Update()
        {
            _cubeCounterText.text = "Cube Count: " + _query.CalculateEntityCount();
        }
    }
}
