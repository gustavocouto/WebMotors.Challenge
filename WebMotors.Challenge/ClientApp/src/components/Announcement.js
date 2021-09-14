import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router';
import { Col, Container, Label, Row } from 'reactstrap';

export default function NewAnnouncement() {
  const {id} = useParams();
  const [makes, setMakes] = useState(null);
  const [selectedMake, setSelectedMake] = useState(null);
  const [models, setModels] = useState(null);
  const [selectedModel, setSelectedModel] = useState(null);
  const [versions, setVersions] = useState(null);
  const [selectedVersion, setSelectedVersion] = useState(null);
  const [year, setYear] = useState(null);
  const [mileage, setMileage] = useState(null);
  const [comments, setComments] = useState(null);

  const filterMakes = async () => {
    return fetch('makes')
      .then(_ => _.json())
      .then(makes => {
        setMakes(makes);
        return makes;
      });
  };

  const filterModels = async (makeId) => {
    makeId = makeId || (makes && selectedMake && makes.find(_ => _.name == selectedMake).id);
    if(!makeId)
      return;

    return fetch(`models?makeId=${makeId}`)
      .then(_ => _.json())
      .then(models => {
        setModels(models);
        return models;
      });
  };

  const filterVersions = async (modelId) => {
    modelId = modelId || (models && selectedModel && models.find(_ => _.name == selectedModel).id);
    if(!modelId)
      return;

    return fetch(`versions?modelId=${modelId}`)
      .then(_ => _.json())
      .then(versions => {
        setVersions(versions);
        return versions;
      });
  };

  useEffect(() => {
    (async () => {
      if(!id) {
        filterMakes();
      } else {
        const initialAnnouncement = await fetch(`announcements/${id}`).then(_ => _.json());
        setYear(initialAnnouncement.year);
        setMileage(initialAnnouncement.mileage);
        setComments(initialAnnouncement.comments);
        setSelectedMake(initialAnnouncement.make);
        setSelectedModel(initialAnnouncement.model);
        setSelectedVersion(initialAnnouncement.version);
        const filteredMakes = await filterMakes();
        const filteredModels = await filterModels(filteredMakes.find(_ => _.name == initialAnnouncement.make).id);
        await filterVersions(filteredModels.find(_ => _.name == initialAnnouncement.model).id);
      }
    })();
  }, []);

  useEffect(() => {
    filterModels();
    setModels(null);
    setVersions(null);
  }, [selectedMake]);

  useEffect(() => {
    filterVersions();
  }, [selectedModel]);

  const saveAnnouncement = async (e) => {
    e.preventDefault();

    const announcement = {
      	make: selectedMake,
        model: selectedModel,
        version: selectedVersion,
        year: parseInt(year),
        mileage: parseInt(mileage),
        comments
    };

    const method = id ? 'PUT' : 'POST';
    if(id)
      announcement.id = parseInt(id);

    try {
      await fetch('announcements', {
        method: method,
        body: JSON.stringify(announcement),
        headers: { 'Content-Type': 'application/json', 'Accept': 'application/json' }
      });
  
      window.location.href = '/';
    } catch (e) {
      console.log(e);
    }
  };

  return (
    <div>
      <form onSubmit={saveAnnouncement}>
        <h1>Novo Anúncio</h1>
        <Container>
          <Row className="form-group">
            <Col>
              <Label>Marca</Label>
              <br />
              <select className="input" style={{width: '100%'}} onChange={e => {
                if(!e.target.value)
                  return;

                setSelectedMake(e.target.value);
                setSelectedModel(null);
                setSelectedVersion(null);
                // selectModel();
              }} required value={selectedMake || ''}>
                {!selectedMake && makes && <option>Selecione...</option>}
                {makes && makes.map((make, i) => <option value={make.name || ''}
                  key={make.name}>{make.name}</option>)}
              </select>
            </Col>
            <Col>
              <Label>Modelo</Label>
              <br />
              <select className="input" style={{width: '100%'}} onChange={e => {
                if(!e.target.value)
                  return;

                setSelectedModel(e.target.value);
                setSelectedVersion(null);
              }} required value={selectedModel || ''}>
                {!selectedModel && models && <option>Selecione...</option>}
                {models && models.map((model, i) => <option value={model.name}
                  key={model.name}>{model.name}</option>)}
              </select>
            </Col>
            <Col>
              <Label>Versão</Label>
              <br />
              <select className="input" style={{width: '100%'}} onChange={e => (e.target.value && setSelectedVersion(e.target.value))} required  value={selectedVersion || ''}>
                {!selectedVersion && versions && <option>Selecione...</option>}
                {versions && versions.map(version => <option value={version.name || ''}
                  key={version.name}>{version.name}</option>)}
              </select>
            </Col>
          </Row>
          <Row className="form-group">
            <Col>
              <Label>Ano</Label>
              <br />
              <input style={{width: '100%'}}
                onChange={e => setYear(e.target.value)}
                value={year || ''}
                className="input" type="number" required/>
            </Col>
            <Col>
              <Label>Quilometragem</Label>
              <br />
              <input style={{width: '100%'}}
                onChange={e => setMileage(e.target.value)}
                value={mileage || ''}
                className="input" type="number" required/>
            </Col>
          </Row>
          <Row className="form-group">
            <Col>
              <Label>Observações</Label>
              <br />
              <textarea style={{width: '100%'}}
                onChange={e => setComments(e.target.value)}
                value={comments || ''}
                rows="3" required></textarea>
            </Col>
          </Row>
          <Row>
            <Col>
              <button type="submit" className="btn btn-primary">Salvar</button>
            </Col>
          </Row>
        </Container>
      </form>
    </div>
  );
}