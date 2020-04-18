DELIMITER $$


CREATE PROCEDURE =`root`@`localhost` PROCEDURE `Insertstreetart` (
                                in GpsLatitude FLOAT( 10, 6 ),
                                in GpsLongitude FLOAT( 10, 6 ),
                                 in Title VARCHAR(45),
                                  in Street VARCHAR(45),
                                   in Timestamp DATE,
                                   in Image VARCHAR(60),
                                   in UserAccountId INT,
                                  )
                                 
BEGIN
INSERT INTO `limerickstreetart`.`streetart`
(`Id`,
`GpsLatitude`,
`GpsLongitude`,
`Title`,
`Street`,
`Timestamp`,
`Image`,
`UserAccountId`)
VALUES
(<{Id: }>,
<{GpsLatitude: }>,
<{GpsLongitude: }>,
<{Title: }>,
<{Street: }>,
<{Timestamp: }>,
<{Image: }>,
<{UserAccountId: }>);
END$$
DELIMITER ;
