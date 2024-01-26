USE BolsaEmpleoDB;

INSERT INTO Vacancies (Code, Position, Description, Company, Salary, Created, Modified)
VALUES ('RS001', N'Ingeniero Industrial',
        N'Se requiere Ingeniero Industrial con mínimo 2 años de experiencia en Salud Ocupacional', 'EPM', 2500000, GETUTCDATE(), GETUTCDATE()),
       ('RS002', N'Profesor de Química', N'Se requiere Químico con mínimo 3 años de experiencia en docencia.',
        N'INSTITUCIÓN EDUCATIVA IES', 1900000, GETUTCDATE(), GETUTCDATE()),
       ('RS003', 'Ingeniero de Desarrollo Junior',
        N'Se requiere Ingeniero de Sistemas con mínimo 1 año de experiencia en Desarrollo de Software en tecnología JAVA.',
        N'XRM SERVICES', 2600000, GETUTCDATE(), GETUTCDATE()),
       ('RS004', N'Coordinador de Mercadeo',
        N'Se necesita Coordinador de Mercadeo con estudios Tecnológicos graduado y experiencia mínima de un año.',
        'INSERCOL', 1350000, GETUTCDATE(), GETUTCDATE()),
       ('RS005', N'Profesor de Matemáticas',
        N'Se requiere Licenciado en Matemáticas o Ingeniero con mínimo 2 años de experiencia en docencia.', 'SENA',
        1750000, GETUTCDATE(), GETUTCDATE()),
       ('RS006', N'Mensajero', N'Se requiere mensajero con moto, con documentos al día y buenas relaciones personales',
        'SERVIENTREGA', 950000, GETUTCDATE(), GETUTCDATE()),
       ('RS007', N'Cajero',
        N'Se requiere cajero para almacén de cadena con experiencia mínima de un año, debe disponer de tiempo por cambios de turnos.',
        N'ALMACENES ÉXITO', 850000, GETUTCDATE(), GETUTCDATE());