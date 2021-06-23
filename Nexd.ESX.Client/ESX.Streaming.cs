namespace Nexd.ESX.Client
{
    using System;
    using System.Runtime.InteropServices;

    public static partial class ESX
    {
        public static class Streaming
        {
            public static dynamic Raw => ESX.Raw.Streaming;

            public static int RequestAnimDict(string animDict, [Optional()] Action callback) => Raw.RequestAnimDict(animDict, callback);
            public static int RequestAnimSet(string animSet, [Optional()] Action callback) => Raw.RequestAnimSet(animSet, callback);
            public static int RequestModel(string model, [Optional()] Action callback) => Raw.RequestModel(model, callback);
            public static int RequestNamedPtfxAsset(string assetName, [Optional()] Action callback) => Raw.RequestNamedPtfxAsset(assetName, callback);
            public static int RequestStreamedTextureDict(string textureDict, [Optional()] Action callback) => Raw.RequestStreamedTextureDict(textureDict, callback);
            public static int RequestWeaponAsset(string hash, [Optional()] Action callback) => Raw.RequestWeaponAsset(hash, callback);
        }
    }
}