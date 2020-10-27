using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intarfaces
{

	abstract class Part : IPart
	{
		public enum PartType
		{
			None,
			Doors,
			Window,
			Roof, 
			Basement,
			Walls,
		}

		public PartStatus Status { get; set; }

		public PartType Type { get; protected set; }

		protected void UniversalBuild(Worker worker) 
		{
			Console.Write($"builder : {worker.Name}, build : {this.Type}");
		}

		public abstract void Build(Worker worker);

		public IPart Clone() 
		{
			return this;
		}
	}

	class Basement : Part
	{
		public enum BasementType 
		{
			None,
			Slab,
			Pile,
			Tape,
			Columnar,
			
		}

		public BasementType TypeOfBasement { get; set; }

		public Basement()
		{
			this.Type = PartType.Basement;
		}

		public Basement(BasementType typeOfBasement) 
		{
			this.Type = PartType.Basement;
			this.TypeOfBasement = typeOfBasement;
		}

		public override void Build(Worker worker) 
		{
			base.UniversalBuild(worker);
			Console.WriteLine($", Type : {this.TypeOfBasement}");
		}
	}

	class Wall : Part
	{
		public enum WallType
		{
			None,
			Brick,
			Printed,
			Block,
			Panel,
		}

		public WallType TypeOfWall { get; set; }

		public Wall()
		{
			this.Type = PartType.Walls;
		}

		public Wall(WallType typeOfWall)
		{
			this.Type = PartType.Walls;
			this.TypeOfWall = typeOfWall;
		}

		public override void Build(Worker worker)
		{
			base.UniversalBuild(worker);
			Console.WriteLine($", Type : {this.TypeOfWall}");
		}
	}
	class Roof : Part
	{
		public enum RoofType
		{
			None,
			Tiling,
			MetalicTiling,
			Leaf,
			Slate
		}

		public RoofType TypeOfRoof { get; set; }

		public Roof()
		{
			this.Type = PartType.Roof;
		}

		public Roof(RoofType typeOfRoof)
		{
			this.Type = PartType.Roof;
			this.TypeOfRoof = typeOfRoof;
		}

		public override void Build(Worker worker)
		{
			base.UniversalBuild(worker);
			Console.WriteLine($", Type : {this.TypeOfRoof}");
		}
	}
	class Window : Part
	{
		public enum WindowType
		{
			None,
			Wooden,
			Plastic,
			Frameless
		}

		public WindowType TypeOfWindow { get; set; }

		public Window()
		{
			this.Type = PartType.Window;
		}

		public Window(WindowType typeOfWindow)
		{
			this.Type = PartType.Window;
			this.TypeOfWindow = typeOfWindow;
		}

		public override void Build(Worker worker)
		{
			base.UniversalBuild(worker);
			Console.WriteLine($", Type : {this.TypeOfWindow}");
		}
	}
	class Door : Part
	{
		public enum DoorType
		{
			None,
			Metalic,
			Glass,
			Wooden,
			Plastic,
			Golden
		}

		public DoorType TypeOfDoor { get; set; }

		public Door()
		{
			this.Type = PartType.Doors;
		}

		public Door(DoorType typeOfDoor)
		{
			this.Type = PartType.Doors;
			this.TypeOfDoor = typeOfDoor;
		}

		public override void Build(Worker worker)
		{
			base.UniversalBuild(worker);
			Console.WriteLine($", Type : {this.TypeOfDoor}");
		}
	}
	

	
}
