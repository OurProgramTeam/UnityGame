using System.Collections.Generic;

namespace Scripts.Gameplay.Fields
{
    //Чтобы можно было без проблем подменить получение полей,
    //Например из файла конфига или прямо в коде
    public interface IFieldsService
    {
        List<Field> GetFields();
    }
}