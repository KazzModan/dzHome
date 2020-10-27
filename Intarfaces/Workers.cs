using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Intarfaces
{
	class Worker : IWorker
	{
        public string Name { get; set; }

        public Worker()
		{
			this.Name = "Kolya";
		}
		public void Build(IPart part)
		{
			if (part is Part)
			{
				(part as Part).Build(this);
				(part as Part).Status = PartStatus.Done;
			}
		}
		public Worker(string name)
		{
			this.Name = name;
		}

		
	}

	class House
	{
		public List<Part> parts;

		public House()
		{
			this.parts = new List<Part>()
			{
				new Basement(Basement.BasementType.Columnar),
				new Wall(Wall.WallType.Panel),
				new Wall(Wall.WallType.Brick),
				new Wall(Wall.WallType.Block),
				new Wall(Wall.WallType.Printed),
				new Door(Door.DoorType.Golden),
				new Window(Window.WindowType.Frameless),
				new Roof(Roof.RoofType.Slate)
			};
		}

		public bool GetBuiltStatus() 
		{
			foreach (var item in parts)
				if (item.Status != PartStatus.Done)
					return false;

			return true;
		}
	}

	class Team 
	{
		private List<Worker> workers;

		public Team()
		{
			this.workers = new List<Worker>()
			{
				new Worker("Sanya"),
				new Worker("Jeka"),
				new Worker("Vasya"),
				new Worker("Vitya"),
				new Worker("Petya")
			};
		}

		public void Build(House house) 
		{
			do
			{
				foreach (var worker in workers)
					foreach (var part in house.parts)
						if (part.Status != PartStatus.Done)
						{
							part.Status = PartStatus.Done;
							worker.Build(part);
							TeamLeader.ShowStatus(house);
							break;
						}
			} while (!house.GetBuiltStatus());
			ShowHouse();
		}

		private void ShowHouse() 
		{
			if(!File.Exists("../../house.txt")) 
			{
				Console.WriteLine("sorry image with house was deleted");
				return;
			}

			string allText = File.ReadAllText("../../house.txt");
			string[] house = allText.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			
			int Height = house.Length;
			int left = Console.CursorLeft + 10;
			int top = Console.CursorTop + Height + 2;

			for (int i = 0; i < Height; i++)
			{
				Console.SetCursorPosition(left, top--);
				Console.WriteLine(house[i]);
				System.Threading.Thread.Sleep(50);
			}

			Console.SetCursorPosition(0, Console.CursorTop + Height + 1);
			Console.WriteLine("DONE");
		}
	}

	static class TeamLeader 
	{
		static public void ShowStatus(House house) 
		{
			Console.Write("\nDONE: ");
			
			foreach (var item in house.parts)
				if(item.Status == PartStatus.Done)
					Console.Write("{0}, ", item.Type);

			Console.WriteLine();
		}
	}
	
}
