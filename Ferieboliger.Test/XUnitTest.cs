using Ferieboliger.BLL.Services;
using Ferieboliger.DAL.Context;
using Ferieboliger.DAL.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Ferieboliger.Test
{
    public class XUnitTest
    {
        [Fact]
        public async void FacilitetService_ShouldReturnListOfFacilities()
        {
            var context = new FerieboligDbContext();
            var facilitetService = new FacilitetService(context);

            var result = await facilitetService.GetFacilitiesAsync();

            Assert.IsType<List<Facilitet>>(result);
        }

        [Fact]
        public async void AddFerieboligAsync_ShouldCreateFeriebolig()
        {

            // arrange
            var context = new FerieboligDbContext();
            var adresseService = new AdresseService(context);

            var ferieboligService = new FerieboligService(context, adresseService);

            var expected = new Feriebolig()
            {
                Adresse = new Adresse()
                {
                    By = "Test",
                    Land = "Danmark",
                    Postnummer = "6000",
                    Vej = "test vej 12"
                },
                AfstandIndkoeb = 10,
                AfstandRestaurant = 10,
                AfstandStrand = 10,
                AntalHusdyr = 1,
                AntalBadevaerelser = 2,
                AntalKvadratmeter = 100,
                AntalPersoner = 4,
                AntalSovepladser = 4,
                Type = DAL.Models.Enums.FerieboligType.Feriebolig,
                AfgangTidspunkt = null,
                AnkomstTidspunkt = null,
                BeskatningHoejUge = 1,
                BeskatningHoejWeekend = 1,
                BeskatningLavUge = 1,
                BeskatningLavWeekend = 1,
                Bookinger = null,
                Faciliteter = null,
                HusdyrTilladt = true,
                SendNoegler = true,
                PrisHoejUge = 1,
                PrisHoejWeekend = 1,
                PrisLavUge = 1,
                PrisLavWeekend = 1,
                Grundareal = 50,
                NoeglerTilgaengelig = 1,
                Spaerringer = null
            };

            // act
            var result = await ferieboligService.AddFerieboligAsync(expected);

            // assert
            Assert.NotNull(result);
            Assert.IsType<Feriebolig>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public async void GetUserByEmail_ShouldReturnTheSpecifiedUser_ByEmail()
        {
            // arrange
            var context = new FerieboligDbContext();
            var brugerService = new BrugerService(context);

            var email = "pensionist@pensionist.com";

            // act
            var result = await brugerService.GetUserByEmailAsync(email);

            // assert
            Assert.Equal(email, result.Email);
        }
    }
}
