namespace Morpeh.Globals {
    using System;
    using System.Collections.Generic;
    using Unity.IL2CPP.CompilerServices;
    using UnityEngine;
    using Object = UnityEngine.Object;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Globals/Variable List Object")]
    public class GlobalVariableListObject : BaseGlobalVariable<List<Object>> {
        public override bool CanBeAutoSaved => false;

        protected override List<Object> Load(string serializedData) => JsonUtility.FromJson<ListObjectWrapper>(serializedData).list;

        protected override string Save() => JsonUtility.ToJson(new ListObjectWrapper{list = this.value});

        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
        [Serializable]
        private struct ListObjectWrapper {
            public List<Object> list;
        }
    }
}