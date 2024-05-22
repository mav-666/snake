using System.Collections;
using UnityEngine;

namespace Electricity.Couplers
{
    public abstract class CoolDownCoupler : FindingCoupler
    {
        [SerializeField] private float coolDownTime;

        private bool _isCoolDown;

        public override void FindA()
        {
            if(_isCoolDown)
                return;
            
            base.FindA();
        }
        
        public override void FindB()
        {
            if(_isCoolDown)
                return;
            
            base.FindB();
        }

        public override void BreakA()
        {
            StartCoroutine(CoolDown());
            base.BreakA();
        }

        public override void BreakB()
        {
            StartCoroutine(CoolDown());
            base.BreakB();
        }

        private IEnumerator CoolDown()
        {
            _isCoolDown = true;
            yield return new WaitForSeconds(coolDownTime);
            _isCoolDown = false;
        }
    }
}