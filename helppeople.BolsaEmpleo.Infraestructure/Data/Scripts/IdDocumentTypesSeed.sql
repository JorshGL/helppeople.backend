USE BolsaEmpleoDB;

INSERT INTO IdDocumentTypes (Name, Created, Modified) 
VALUES (N'Cédula de Ciudadanía', GETUTCDATE(), GETUTCDATE()),
       (N'Cédula de Extranjería', GETUTCDATE(), GETUTCDATE()),
       (N'Pasaporte', GETUTCDATE(), GETUTCDATE()),
       (N'Otro', GETUTCDATE(), GETUTCDATE());