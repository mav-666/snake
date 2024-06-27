using System;
using UnityEngine;

namespace Electricity.Couplers
{
    public abstract class FindingCoupler : Coupler
    {
        [SerializeField] private Finder finderA;
        [SerializeField] private Finder finderB;

        [SerializeField] private Order findFirst;
        [SerializeField] private Order breakFirst;
        
        public bool IsConnectedA { get; private set; }
        public bool IsConnectedB { get; private set; }

        public event Action<Order> OnConnect;
        public event Action<Order> OnDisconnect;
        
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
            
            if(IsConnectedA)
                OnConnect?.Invoke(Order.A);
            
            CheckInit();
        }
        
        public virtual void FindB()
        {
            if(IsConnectedB)
                return;
            
            IsConnectedB = finderB.Find(out B) && B != A;
            
            if(IsConnectedB)
                OnConnect?.Invoke(Order.B);
            
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
            if(IsConnectedA)
                OnDisconnect?.Invoke(Order.A);
            
            IsConnectedA = false;
            CheckBreak();
        }

        public virtual void BreakB()
        {
            if(IsConnectedB)
                OnDisconnect?.Invoke(Order.B);
            
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