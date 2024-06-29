using System;
using UnityEngine;
using Utils;

namespace Electricity.Couplers.Electrons
{
    public class SplineElectronPool : ObjectPool<SplineElectron>
    {
        public enum ElectronLayer {Floor, Above}

        [SerializeField] private ElectronLayer electronLayer;

        public ElectronLayer ElectronType => electronLayer;
    }
}