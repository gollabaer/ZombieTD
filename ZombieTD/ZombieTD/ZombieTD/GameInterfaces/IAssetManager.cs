using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace ZombieTD
{
    public interface IAssetManager
    {
        void LoadAssets(ContentManager content);
        I GetAsset<T, I>(T enumItem) where I : ICloneable;
    }
}
