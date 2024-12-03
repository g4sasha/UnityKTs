using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Formula/Simple Formula", fileName = "NewFormula")]
    public class FormulaSO : ScriptableObject
    {
        public double G = 9.81;
        public double C = 299792458.0;

        [field: SerializeField]
        public string Formula { get; private set; }
    }

    [CreateAssetMenu(menuName = "Formula/Energy Connection Formula", fileName = "NewFormula")]
    public class EnergyConnectionFormulaSO : FormulaSO
    {
        [field: SerializeField]
        public double Mass { get; private set; }
    }
}
