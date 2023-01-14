using System.Collections.Generic;
using System.Linq;
using ShapesXr.Import.Core;
using UnityEngine;

namespace ShapesXr
{
    public static class InitializerFactory
    {
        private static readonly SizeInitializer SizeInitializer = new SizeInitializer();
        private static readonly TextInitializer TextInitializer = new TextInitializer();
        private static readonly ImageInitializer ImageInitializer = new ImageInitializer();
        private static readonly ModelInitializer ModelInitializer = new ModelInitializer();
        private static readonly GroupInitializer GroupInitializer = new GroupInitializer();
        
        public static IInitializer GetInitializer(PropertyReactorComponent reactor, BasePreset preset)
        {
            if (reactor is CharacterReactorComponent)
            {
                return GetCharacterInitializer(preset);
            }
            else if (reactor is SizePropertyReactor)
            {
                return SizeInitializer;
            }
            else if (reactor is TextReactorComponent)
            {
                return TextInitializer;
            }
            else if (reactor is StrokePropertyReactor)
            {
                return GetStrokeInitializer(preset);
            }
            else if (reactor is ImageReactor)
            {
                return ImageInitializer;
            }
            else if (reactor is ModelReactor)
            {
                return ModelInitializer;
            }
            else if (reactor is BaseMaterialReactor r)
            {
                return GetMaterialInitializer(r);
            }
            else if (reactor is GroupPropertyReactor)
            {
                return GroupInitializer;
            }

            return new NullInitializer(reactor.ToString());
        }

        private static IInitializer GetCharacterInitializer(BasePreset preset)
        {
            if (preset is CharacterPreset characterPreset)
            {
                return new CharacterInitializer(characterPreset.Pose);
            }

            return new NullInitializer(preset.name);
        }

        private static IInitializer GetStrokeInitializer(BasePreset preset)
        {
            if (preset is BaseBrushPreset p)
            {
                return new StrokeInitializer(p.GetParameters());
            }

            return new NullInitializer(preset.ToString());
        }

        private static IInitializer GetMaterialInitializer(BaseMaterialReactor reactor)
        {
            List<MeshRenderer> renderers;
            
            var materialAssigner = reactor.GetComponent<MaterialAssigner>();

            if (materialAssigner)
            {
                renderers = new List<MeshRenderer>();

                foreach (var group in materialAssigner.Groups)
                {
                    foreach (var renderer in group.Renderers)
                    {
                        if(renderer is MeshRenderer meshRenderer)
                        {
                            renderers.Add(meshRenderer);
                        }
                    }
                }
            }
            else
            {
                renderers = reactor.GetComponentsInChildren<MeshRenderer>().ToList();
            }

            if (reactor is MaterialReactor)
            {
                return new MaterialInitializer(renderers);
            }
            else if (reactor is ImageMaterialReactor)
            {
                return new ImageMaterialInitializer(renderers);
            }
            else if (reactor is ModelMaterialReactor)
            {
                return new ModelMaterialInitializer(renderers);
            }

            return new NullInitializer(reactor.ToString());
        }
    }
}