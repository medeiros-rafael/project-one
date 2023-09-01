using AutoMapper;

namespace DAL
{
    public class Base<TModel, TDto>
    {
        private IMapper mapperModel;
        private IMapper mapperDto;
        private MapperConfiguration configuration;

        public Base()
        {

        }

        public TDto ConvertToDto(TModel model)
        {
            configuration = new MapperConfiguration(cfg => cfg.CreateMap<TModel, TDto>());

            mapperModel = configuration.CreateMapper();

            return mapperModel.Map<TDto>(model);
        }

        public TModel ConvertToModel(TDto dto)
        {
            configuration = new MapperConfiguration(cfg => cfg.CreateMap<TDto, TModel>());

            mapperDto = configuration.CreateMapper();

            return mapperDto.Map<TModel>(dto);
        }

        public List<TDto> ConvertClass(List<TModel> models)
        {
            configuration = new MapperConfiguration(cfg => cfg.CreateMap<TModel, TDto>());

            mapperModel = configuration.CreateMapper();

            return mapperModel.Map<List<TDto>>(models);
        }
    }

    public interface DALBase<TDto>
    {
        List<TDto> Get(TDto dto);
        TDto Search(TDto dto);
        void Insert(TDto dto);
        void Delete(int pk);
        void Update(TDto dto);
    }
}
