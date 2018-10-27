// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
namespace Eco.Mods.TechTree
{
    using System;
    using System.ComponentModel;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Stats;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Objects;

    [Category("Hidden")]
    public partial class AxeItem
    {
        private static IDynamicValue caloriesBurn;
        private static IDynamicValue damage;
        static AxeItem()
        {
            string axeUiLink = new AxeItem().UILink();
            caloriesBurn = new ConstantValue(0);
            damage = new ConstantValue(100);
        }
        private static IDynamicValue skilledRepairCost = new ConstantValue(1);
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }

        public override Item RepairItem { get { return Item.Get<StoneItem>(); } }
        public override int FullRepairAmount { get { return 1; } }

        public override IDynamicValue CaloriesBurn   { get { return caloriesBurn; } }
        public override IDynamicValue Damage         { get { return damage; } }
        
        public override string LeftActionDescription { get { return "Chop"; } }

        public override InteractResult OnActLeft(InteractionContext context)
        {
			InventoryChangeSet changes = new InventoryChangeSet(context.Player.User.Inventory, context.Player.User);

			Random r = new System.Random();
			int MYpp = r.Next(100);
            if (context.HasBlock)
            {
                var block = World.GetBlock(context.BlockPosition.Value);
                if (block.Is<TreeDebris>())
                {
					if (MYpp <= 4)
					{
						changes.AddItems<MYBeehiveItem>(1);
						changes.AddItems<WoodPulpItem>(4);
					}
					else if (MYpp <= 20)
					{
						changes.AddItems<MYPlumItem>(2);
						changes.AddItems<WoodPulpItem>(4);
					}
					else
					{
						changes.AddItems<WoodPulpItem>(5);
					}
                    IAtomicAction lawAction = PlayerActions.PickUp.CreateAtomicAction(context.Player, Get<WoodPulpItem>(), context.BlockPosition.Value);
                    return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 3, null, changes, lawAction);
                }
                else
                    return InteractResult.NoOp;
            }
            else
			{
//						context.Player.SendTemporaryMessageLoc(MYpp.ToString());
				if (context.Target.GetType().Name.ToString() == "MYCuttingBoardObject")
				{
					if (MYpp <= 4)
					{
//						changes.AddItems<BisonFemaleItem>(1);
					}
					else if (MYpp <= 20)
					{
						changes.AddItems<BisonCarcassItem>(1);
					}
					else if (MYpp <= 50)
					{
						changes.AddItems<ElkCarcassItem>(1);
					}
					(context.Target as WorldObject).Destroy();
				}
                return base.OnActLeft(context);
			}
        }

        public override bool ShouldHighlight(Type block)
        {
            return Block.Is<TreeDebris>(block);
        }
    }
}