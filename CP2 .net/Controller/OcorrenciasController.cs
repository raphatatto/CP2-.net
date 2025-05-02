public class OcorrenciasController : Controller
{
    private static List<Ocorrencia> ocorrencias = new();

    public ActionResult Index()
    {
        return View(ocorrencias);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Ocorrencia o)
    {
        o.Id = ocorrencias.Count + 1;
        o.DataHora = DateTime.Now;
        ocorrencias.Add(o);
        return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
        var o = ocorrencias.FirstOrDefault(x => x.Id == id);
        return View(o);
    }

    [HttpPost]
    public ActionResult Edit(Ocorrencia o)
    {
        var oc = ocorrencias.FirstOrDefault(x => x.Id == o.Id);
        if (oc != null)
        {
            oc.PlacaMoto = o.PlacaMoto;
            oc.Descricao = o.Descricao;
            oc.Vaga = o.Vaga;
        }
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        var o = ocorrencias.FirstOrDefault(x => x.Id == id);
        return View(o);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var o = ocorrencias.FirstOrDefault(x => x.Id == id);
        if (o != null)
            ocorrencias.Remove(o);
        return RedirectToAction("Index");
    }
}
