-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 20-Dez-2022 às 00:27
-- Versão do servidor: 10.4.24-MariaDB
-- versão do PHP: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `dbgallery`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `galeria`
--

CREATE TABLE `galeria` (
  `IdGallery` int(11) NOT NULL,
  `Title` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `galeria`
--

INSERT INTO `galeria` (`IdGallery`, `Title`) VALUES
(1, 'Cidades'),
(2, 'Aurora Boreal 2001'),
(3, 'Carros Esportivos'),
(4, 'Natureza');

-- --------------------------------------------------------

--
-- Estrutura da tabela `imagem`
--

CREATE TABLE `imagem` (
  `IdImage` int(11) NOT NULL,
  `ImageTitle` longtext NOT NULL,
  `IdGallery` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `imagem`
--

INSERT INTO `imagem` (`IdImage`, `ImageTitle`, `IdGallery`) VALUES
(28, 'City 1', 1),
(29, 'City 2', 1),
(30, 'City 3', 1),
(31, 'City 4', 1),
(32, 'City 5', 1),
(33, 'City 6', 1),
(34, 'Aurora 1', 2),
(35, 'Aurora 2', 2),
(36, 'Aurora 3', 2),
(38, 'Aurora 4', 2),
(39, 'Aurora 5', 2),
(40, 'Aurora 6', 2),
(41, 'Car 1', 3),
(42, 'Car 2', 3),
(43, 'Car 3', 3),
(45, 'Car 4', 3),
(46, 'Car 5', 3),
(47, 'Car 6', 3),
(48, 'Nature 1', 4),
(49, 'Nature 2', 4),
(50, 'Nature 3', 4),
(51, 'Nature 4', 4),
(52, 'Nature 5', 4),
(53, 'Nature 6', 4);

-- --------------------------------------------------------

--
-- Estrutura da tabela `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20221219123554_v5', '3.0.0');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `galeria`
--
ALTER TABLE `galeria`
  ADD PRIMARY KEY (`IdGallery`);

--
-- Índices para tabela `imagem`
--
ALTER TABLE `imagem`
  ADD PRIMARY KEY (`IdImage`),
  ADD KEY `IX_Imagem_IdGallery` (`IdGallery`);

--
-- Índices para tabela `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `galeria`
--
ALTER TABLE `galeria`
  MODIFY `IdGallery` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `imagem`
--
ALTER TABLE `imagem`
  MODIFY `IdImage` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=54;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `imagem`
--
ALTER TABLE `imagem`
  ADD CONSTRAINT `FK_Imagem_Galeria_IdGallery` FOREIGN KEY (`IdGallery`) REFERENCES `galeria` (`IdGallery`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
