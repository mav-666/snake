using UnityEngine;

namespace Electricity.Couplers
{
    public abstract class FindingCoupler : Coupler
    {
        private enum Order {A, B}
        
        [SerializeField] private Finder finderA;
        [SerializeField] private Finder finderB;

        [SerializeField] private Order findFirst;
        [SerializeField] private Order breakFirst;
        
        public bool IsConnectedA { get; private set; }
        public bool IsConnectedB { get; private set; }
        
        public void FindUnconnected()
        {
            if (findFirst == Order.A && !IsConnectedA || findFirst == Order.B && IsConnectedB)
                FindA();
            else
                FindB();
        }

        public virtual void FindA()
        {
            if(IsConnectedA)
                return;
            
            IsConnectedA = finderA.Find(out A) && A != B;
            CheckInit();
        }
        
        public virtual void FindB()
        {
            if(IsConnectedB)
                return;
            
            IsConnectedB = finderB.Find(out B) && B != A;
            
            CheckInit();
        }

        private void CheckInit()
        {
            if(IsConnectedA && IsConnectedB && !IsConnected)
                Init(A, B);
        }
        
        public void BreakConnected()
        {
            if (breakFirst == Order.A && IsConnectedA || breakFirst == Order.B && !IsConnectedB)
                BreakA();
            else
                BreakB();
        }
        
        public virtual void BreakA()
        {
            IsConnectedA = false;
            CheckBreak();
        }

        public virtual void BreakB()
        {
            IsConnectedB = false;
            CheckBreak();
        }

        private void CheckBreak()
        {
            if(IsConnected)
                Break();
        }
    }
}