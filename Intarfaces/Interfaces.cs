using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intarfaces
{
	enum PartStatus
	{
		None,
		Зrogress,
		Done
	}

	interface IPart
	{
		PartStatus Status { get; set; }
		IPart Clone();
	}
	
	interface IWorker 
	{
		void Build(IPart part);
	}
}
