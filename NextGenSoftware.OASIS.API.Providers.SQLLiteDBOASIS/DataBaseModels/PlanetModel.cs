using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NextGenSoftware.OASIS.API.Core.Interfaces.STAR;
using NextGenSoftware.OASIS.API.Providers.SQLLiteDBOASIS.Prototypes;

namespace NextGenSoftware.OASIS.API.Providers.SQLLiteDBOASIS.DataBaseModels{

    [Table("Planet")]
    public class PlanetModel : CelestialBodyAbstract{

        [Required, Key]
        public String PlanetId{ set; get; }
        
        public String SolarSystemId{ set; get; }
        public String GalaxyId{ set; get; }
        public String GalaxyClusterId{ set; get; }
        public String UniverseId{ set; get; }

        public List<MoonModel> Moons{ set; get;}

        public PlanetModel():base(){}
        public PlanetModel(IPlanet source):base(){

            if(source.Id == Guid.Empty){
                source.Id = Guid.NewGuid();
            }
        
            this.PlanetId = source.Id.ToString();
            this.HolonId = source.ParentHolonId.ToString();

            this.SpaceQuadrant = source.SpaceQuadrant;
            this.SpaceSector = source.SpaceSector;
            this.SuperGalacticLatitute = source.SuperGalacticLatitute;
            this.SuperGalacticLongitute = source.SuperGalacticLongitute;
            this.GalacticLatitute = source.GalacticLatitute;
            this.GalacticLongitute = source.GalacticLongitute;
            this.HorizontalLatitute = source.HorizontalLatitute;
            this.HorizontalLongitute = source.HorizontalLongitute;
            this.EquatorialLatitute = source.EquatorialLatitute;
            this.EquatorialLongitute = source.EquatorialLongitute;
            this.EclipticLatitute = source.EclipticLatitute;
            this.EclipticLongitute = source.EclipticLongitute;
            this.Size = source.Size;
            this.Radius = source.Radius;
            this.Age = source.Age;
            this.Mass = source.Mass;
            this.Temperature = source.Temperature;
            this.Weight = source.Weight;
            this.GravitaionalPull = source.GravitaionalPull;
            this.OrbitPositionFromParentStar = source.OrbitPositionFromParentStar;
            this.CurrentOrbitAngleOfParentStar = source.CurrentOrbitAngleOfParentStar;
            this.DistanceFromParentStarInMetres = source.DistanceFromParentStarInMetres;
            this.RotationSpeed = source.RotationSpeed;
            this.TiltAngle = source.TiltAngle;
            this.NumberRegisteredAvatars = source.NumberRegisteredAvatars;
            this.NunmerActiveAvatars = source.NunmerActiveAvatars;

            this.GenesisType = source.GenesisType;

            if(source.Moons != null){

                this.Moons = new List<MoonModel>();
                foreach(Moon moon in source.Moons){

                    this.Moons.Add(new MoonModel(moon));
                }

            }
        }

        public IPlanet GetPlanet(){
            Planet item=new Planet();

            item.Id = Guid.Parse(this.PlanetId);
            item.ParentHolonId = Guid.Parse(this.HolonId);

            item.SpaceQuadrant = this.SpaceQuadrant;
            item.SpaceSector = this.SpaceSector;
            item.SuperGalacticLatitute = this.SuperGalacticLatitute;
            item.SuperGalacticLongitute = this.SuperGalacticLongitute;
            item.GalacticLatitute = this.GalacticLatitute;
            item.GalacticLongitute = this.GalacticLongitute;
            item.HorizontalLatitute = this.HorizontalLatitute;
            item.HorizontalLongitute = this.HorizontalLongitute;
            item.EquatorialLatitute = this.EquatorialLatitute;
            item.EquatorialLongitute = this.EquatorialLongitute;
            item.EclipticLatitute = this.EclipticLatitute;
            item.EclipticLongitute = this.EclipticLongitute;
            item.Size = this.Size;
            item.Radius = this.Radius;
            item.Age = this.Age;
            item.Mass = this.Mass;
            item.Temperature = this.Temperature;
            item.Weight = this.Weight;
            item.GravitaionalPull = this.GravitaionalPull;
            item.OrbitPositionFromParentStar = this.OrbitPositionFromParentStar;
            item.CurrentOrbitAngleOfParentStar = this.CurrentOrbitAngleOfParentStar;
            item.DistanceFromParentStarInMetres = this.DistanceFromParentStarInMetres;
            item.RotationSpeed = this.RotationSpeed;
            item.TiltAngle = this.TiltAngle;
            item.NumberRegisteredAvatars = this.NumberRegisteredAvatars;
            item.NunmerActiveAvatars = this.NunmerActiveAvatars;

            item.GenesisType = this.GenesisType;

            if(this.Moons != null){

                item.Moons = new List<IMoon>();
                foreach (MoonModel moon in this.Moons)
                {
                    item.Moons.Add(moon.GetMoon());
                }
            }

            return(item);
        }
    }
}