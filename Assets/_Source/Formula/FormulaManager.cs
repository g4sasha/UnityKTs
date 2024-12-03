using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace Formula
{
    public class FormulaManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _blueprint;

        [SerializeField]
        private List<FormulaSO> _formulas;

        private void Start()
        {
            foreach (FormulaSO formulas in _formulas)
            {
                GameObject formula = Instantiate(_blueprint, transform);
            }
        }
    }
}
