using Factory.Models;
using System;
using Factory.Services.Memberships;

namespace Factory.Services
{
    public class MembershipFactory : IMembershipFactory
    {
        private readonly Func<Type, IMembership> _resolver;

        public MembershipFactory(Func<Type, IMembership> resolver)
        {
            _resolver = resolver;
        }

        public IMembership Create(MembershipType type)
        {
            switch (type)
            {
                case MembershipType.Free:
                    return _resolver(typeof(FreeMembership));
                case MembershipType.Bronze:
                    return _resolver(typeof(BronzeMembership));
                case MembershipType.Silver:
                    return _resolver(typeof(SilverMembership));
                case MembershipType.Gold:
                    return _resolver(typeof(GoldMembership));
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}