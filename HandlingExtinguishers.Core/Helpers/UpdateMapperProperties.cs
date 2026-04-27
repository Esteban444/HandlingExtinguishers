namespace HandlingExtinguishers.Core.Helpers
{
    public class UpdateMapperProperties<T, R>
    {
        public Task<T> MapperUpdate( T fromDB, R fromRequest )
        {
            var typeOfSender = fromRequest!.GetType();
            var typeOfReceiver = fromDB!.GetType();

            try
            {
                foreach ( var propertyOfReceiver in typeOfSender.GetProperties() )
                {
                    var propertyOfB = typeOfReceiver.GetProperty( propertyOfReceiver.Name );
                    if ( propertyOfReceiver.GetValue( fromRequest ) != null )
                    {
                        propertyOfB!.SetValue( fromDB, propertyOfReceiver.GetValue( fromRequest ) );
                    }
                }
            }
            catch ( Exception )
            {
                throw;
            } 

            return Task.FromResult( fromDB );
        }
    }
}