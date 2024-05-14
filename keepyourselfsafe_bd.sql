-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 14-Maio-2024 às 18:35
-- Versão do servidor: 10.4.22-MariaDB
-- versão do PHP: 8.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `keepyourselfsafe_bd`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `player_table`
--

CREATE TABLE `player_table` (
  `playerid` int(11) NOT NULL,
  `player_nome` varchar(50) NOT NULL,
  `player_deaths` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `save_data`
--

CREATE TABLE `save_data` (
  `saveId` int(11) NOT NULL,
  `playerid` int(11) NOT NULL,
  `stageid` int(11) NOT NULL,
  `save_totaltime` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `stages_table`
--

CREATE TABLE `stages_table` (
  `stageid` int(11) NOT NULL,
  `stage_nome` varchar(50) NOT NULL,
  `stage_time` time NOT NULL,
  `iscomplete` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `player_table`
--
ALTER TABLE `player_table`
  ADD PRIMARY KEY (`playerid`);

--
-- Índices para tabela `save_data`
--
ALTER TABLE `save_data`
  ADD PRIMARY KEY (`saveId`),
  ADD KEY `stageid` (`stageid`),
  ADD KEY `playerid` (`playerid`);

--
-- Índices para tabela `stages_table`
--
ALTER TABLE `stages_table`
  ADD PRIMARY KEY (`stageid`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `player_table`
--
ALTER TABLE `player_table`
  MODIFY `playerid` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `save_data`
--
ALTER TABLE `save_data`
  MODIFY `saveId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `stages_table`
--
ALTER TABLE `stages_table`
  MODIFY `stageid` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `save_data`
--
ALTER TABLE `save_data`
  ADD CONSTRAINT `save_data_ibfk_1` FOREIGN KEY (`playerid`) REFERENCES `player_table` (`playerid`),
  ADD CONSTRAINT `save_data_ibfk_2` FOREIGN KEY (`stageid`) REFERENCES `stages_table` (`stageid`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
