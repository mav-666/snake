using System.Collections.Generic;
using Electricity.Couplers;
using Electricity.SignalHandlers;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Electricity
{
    public class Electric : MonoBehaviour
    { 
        [SerializeField, HideInInspector] private SignalHandler _signalHandler;
        protected List<Coupler> _couplers;

        [SerializeField, HideInInspector] private bool _hasSignalHandler;

#if UNITY_EDITOR
        private void OnValidate()
        {
            _hasSignalHandler = TryGetComponent(out _signalHandler);
            EditorUtility.SetDirty(this);
        }

        [ContextMenu("receiveSignal")]
        private void ReceiveSignalTest()
        {
            if(_hasSignalHandler)
                _signalHandler.ReceiveSignal();
        }
#endif

        protected virtual void Awake()
        {
            _couplers = new List<Coupler>();
        }

        public void Connect(Coupler coupler)
        {
            _couplers.Add(coupler);
        }

        public void Disconnect(Coupler coupler)
        {
            _couplers.Remove(coupler);
        }

        protected virtual bool SendSignal()
        {
            foreach (var coupler in _couplers)
                coupler.Transmit(this);

            return _couplers.Count != 0;
        }

        public virtual bool ReceiveSignal(Coupler sender)
        {
            if(_hasSignalHandler)
                _signalHandler.ReceiveSignal();

            return false;
        }
    }
}