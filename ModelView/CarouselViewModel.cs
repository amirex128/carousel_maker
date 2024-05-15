using carousel_maker.Models;

namespace carousel_maker.ModelView;

public class CarouselViewModel
{
    public string Text { get; set; }
    public IList<Carousel> Content { get; set; }
}