namespace WebApplicationFacturas.Helpers
{
    public class UpdateMapperProperties<T, R>
    {
        public Task<T> MapperUpdate(T fromDB, R fromRequest)
        {
            // copy fields
            var typeOfSender = fromRequest!.GetType();
            var typeOfReceiver = fromDB!.GetType();
            try
            {
                // copy properties
                foreach (var propertyOfReceiver in typeOfSender.GetProperties())
                {
                    var propertyOfB = typeOfReceiver.GetProperty(propertyOfReceiver.Name);
                    if (propertyOfReceiver.GetValue(fromRequest) != null)
                    {
                        propertyOfB!.SetValue(fromDB, propertyOfReceiver.GetValue(fromRequest));
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Task.FromResult(fromDB);
        }
    }
}