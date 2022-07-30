using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace Yggdrasil.Content.UI;

public class YggdrasilUI : ModSystem
{
	internal RunicWeaponsUI RunicWeaponsUI;

	private UserInterface runicWeaponsInterface;

	public override void Load()
	{
		if (!Main.dedServ)
		{
			RunicWeaponsUI = new RunicWeaponsUI();
			RunicWeaponsUI.Activate();

			runicWeaponsInterface = new UserInterface();
			runicWeaponsInterface.SetState(RunicWeaponsUI);

			//runicWeaponsInterface.CurrentState.Activate();
		}
	}

	public override void Unload()
	{

	}

	public override void UpdateUI(GameTime gameTime)
	{
		runicWeaponsInterface?.Update(gameTime);
	}

	public static void UIInsertIntoLayers(string myLayerName, UserInterface userInterface, List<GameInterfaceLayer> layers, string layerName)
	{
		int index = layers.FindIndex(layer => layer.Name.Equals(layerName));
		layers.Insert(index, new LegacyGameInterfaceLayer(myLayerName,
			delegate
			{
				userInterface.Draw(Main.spriteBatch, new GameTime());
				return true;
			}, InterfaceScaleType.UI)
		);
	}

	public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
	{
		UIInsertIntoLayers("Yggdrasil: Runic Weapon UI", runicWeaponsInterface, layers, "Vanilla: Inventory");
	}
}