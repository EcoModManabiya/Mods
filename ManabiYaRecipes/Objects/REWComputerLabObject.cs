﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Objects;
    using Shared.Serialization;
    using Eco.Gameplay.Property;

    [Serialized]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerGridNetworkComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PowerConsumptionComponent))]                     
    [RequireComponent(typeof(SolidGroundComponent))]            
    [RequireRoomContainment]
    [RequireRoomVolume(45)]                              
    [RequireRoomMaterialTier(3f)]        
    public partial class ComputerLabObject : WorldObject
    {
        public override string FriendlyName { get { return "Computer Lab"; } }

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<MinimapComponent>().Initialize("Computer Lab");
            this.GetComponent<LinkComponent>().Initialize(5);
            this.GetComponent<PowerGridComponent>().Initialize(10.0f, new ElectricPower());
            this.GetComponent<PowerGridNetworkComponent>().Initialize(new Dictionary<Type, int> { { typeof(LaserObject), 4 }, { typeof(ComputerLabObject), 10 } }, true);
        }
    }
}