public class MotosController : Controller
{
	private static List<Moto> motos = new();

	public ActionResult Index()
	{
		return View(motos);
	}

	public ActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public ActionResult Create(Moto moto)
	{
		moto.Id = motos.Count + 1;
		moto.Entrada = DateTime.Now;
		motos.Add(moto);
		return RedirectToAction("Index");
	}

	public ActionResult Edit(int id)
	{
		var moto = motos.FirstOrDefault(m => m.Id == id);
		return View(moto);
	}

	[HttpPost]
	public ActionResult Edit(Moto moto)
	{
		var m = motos.FirstOrDefault(x => x.Id == moto.Id);
		if (m != null)
		{
			m.Placa = moto.Placa;
			m.Modelo = moto.Modelo;
			m.Cor = moto.Cor;
			m.Vaga = moto.Vaga;
		}
		return RedirectToAction("Index");
	}

	public ActionResult Delete(int id)
	{
		var moto = motos.FirstOrDefault(m => m.Id == id);
		return View(moto);
	}

	[HttpPost, ActionName("Delete")]
	public ActionResult DeleteConfirmed(int id)
	{
		var moto = motos.FirstOrDefault(m => m.Id == id);
		if (moto != null)
			motos.Remove(moto);
		return RedirectToAction("Index");
	}
}
