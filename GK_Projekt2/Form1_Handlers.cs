using FastBitmapLib;
using System.Numerics;

namespace GK_Projekt2
{
    partial class Form1
    {
        private void btnStopAnimation_Click(object sender, EventArgs e)
        {
            animationInProgress = false;
        }

        // TBD adjust to multifile editions
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (!animationInProgress)
            {
                //int temp = Math.Min(pPictureBoxPanel.Width, pPictureBoxPanel.Height);
                //pbCanvas.Width = temp;
                //pbCanvas.Height = temp;
                //pbCanvas.Size = new Size(temp, temp);
                //_bitmap = new Bitmap(pbCanvas.Width + 2, pbCanvas.Height + 2);
                //_fastBitmap = new FastBitmap(_bitmap);
                //(ScaledEdgeList, ScaledVertexList, ScaledVertexOrder) = ScaleVertices(_loadedObject.FaceList, pbCanvas.Width, pbCanvas.Height);
                //_filler = new Filler(_loadedObject, pbCanvas.Height, pbCanvas.Width, polySize, ScaledVertexList, ScaledVertexOrder, _texture, _normalMap, isHeightMapEnabled, _bitmap);
                //_filler._texture = new Bitmap(_filler._texture, new Size(_bitmap.Width, _bitmap.Height));
                //_filler._normalMap = new Bitmap(_filler._texture, new Size(_bitmap.Width, _bitmap.Height));
                //SetFillerValues();
                //DrawObjectAnimation();
            }
        }

        private void sbObjectR_Scroll(object sender, ScrollEventArgs e)
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].Io.Item1 = (double)((HScrollBar)sender).Value / 100;
                if (_filler[i].textureColor == false && !animationInProgress)
                    DrawObject();
            }
        }

        private void sbObjectG_Scroll(object sender, ScrollEventArgs e)
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].Io.Item2 = (double)((HScrollBar)sender).Value / 100;
                if (_filler[i].textureColor == false && !animationInProgress)
                    DrawObject();
            }
        }

        private void sbObjectB_Scroll(object sender, ScrollEventArgs e)
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].Io.Item3 = (double)((HScrollBar)sender).Value / 100;
                if (_filler[i].textureColor == false && !animationInProgress)
                    DrawObject();
            }
        }

        private void rbFixedObjectColor_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].textureColor = !rbFixedObjectColor.Checked;
            }
            if (!animationInProgress)
                DrawObject();
        }

        private void btnLoadTexture_Click(object sender, EventArgs e)
        {
            importing = true;
            if (!animationInProgress)
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    dialog.Filter = "Image Files|*.jpg;*.png";
                    dialog.FilterIndex = 2;
                    dialog.RestoreDirectory = true;
                    dialog.Multiselect = true;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        for (var i = 0; i < dialog.FileNames.Length; i++)
                        {
                            _texture[i] = new Bitmap(Image.FromFile(dialog.FileNames[i]));
                            _filler[i]._texture = new Bitmap(
                                _texture[i],
                                new Size(_bitmap[i].Width, _bitmap[i].Height)
                            );
                        }
                    }
                    DrawObject();
                }
            }
            importing = false;
        }

        private void SetFillerValues()
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].textureColor = rbTextureObjectColor.Checked;
                _filler[i].normalVectorModified = cbModifiedNormalVector.Checked;
                _filler[i].light = (
                    sbLightX.Value * pbCanvas.Height / 100,
                    sbLightY.Value * pbCanvas.Height / 100,
                    (int)(sbLightZ.Value * pbCanvas.Height * 1.5 / 100)
                );
                _filler[i].ks = (double)(sbKs.Value / 100m);
                _filler[i].kd = (double)(sbKd.Value / 100m);
                _filler[i].m = sbm.Value;
                _filler[i].Il = (sbLightR.Value / 100, sbLightG.Value / 100, sbLightB.Value / 100);
                _filler[i].Io = (
                    sbObjectR.Value / 100,
                    sbObjectG.Value / 100,
                    sbObjectB.Value / 100
                );
            }
        }

        private void cbModifiedNormalVector_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].normalVectorModified = ((CheckBox)sender).Checked;
            }
            if (!animationInProgress)
                DrawObject();
        }

        private void rbVectors_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].vectorInterpolation = ((RadioButton)sender).Checked;
            }
            if (!animationInProgress)
                DrawObject();
        }

        private void tlpMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (!animationInProgress && !importing)
                DrawObjectAnimation();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].kd = (double)((HScrollBar)sender).Value / 100;
            }
            if (!animationInProgress)
                DrawObject();
        }

        private void sbKs_Scroll(object sender, ScrollEventArgs e)
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].ks = (double)((HScrollBar)sender).Value / 100;
            }
            if (!animationInProgress)
                DrawObject();
        }

        private void sbLightX_Scroll(object sender, ScrollEventArgs e)
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].light.Item1 = (int)(
                    _bitmap[i].Height * 3 * (double)((HScrollBar)sender).Value / 100
                    - pbCanvas.Height
                );
            }
            if (!animationInProgress)
                DrawObject();
        }

        private void sbLightY_Scroll(object sender, ScrollEventArgs e)
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].light.Item2 = (int)(
                    _bitmap[i].Width * 3 * (double)((HScrollBar)sender).Value / 100
                    - pbCanvas.Height
                );
            }
            if (!animationInProgress)
                DrawObject();
        }

        private void sbLightZ_Scroll(object sender, ScrollEventArgs e)
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].light.Item3 = (int)(
                    _bitmap[i].Height / 2
                    + pbCanvas.Height * 2 * (double)((HScrollBar)sender).Value / 100
                );
            }
            if (!animationInProgress)
                DrawObject();
        }

        private void sbm_Scroll(object sender, ScrollEventArgs e)
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].m = (double)((HScrollBar)sender).Value;
            }
            if (!animationInProgress)
                DrawObject();
        }

        private void sbLightR_Scroll(object sender, ScrollEventArgs e)
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].Il.Item1 = (double)((HScrollBar)sender).Value / 100;
            }
            if (!animationInProgress)
                DrawObject();
        }

        private void sbLightG_Scroll(object sender, ScrollEventArgs e)
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].Il.Item2 = (double)((HScrollBar)sender).Value / 100;
            }
            if (!animationInProgress)
                DrawObject();
        }

        private void sbLightB_Scroll(object sender, ScrollEventArgs e)
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].Il.Item3 = (double)((HScrollBar)sender).Value / 100;
            }
            if (!animationInProgress)
                DrawObject();
        }

        private void cbMesh_CheckedChanged(object sender, EventArgs e)
        {
            if (!animationInProgress)
                DrawObject();
        }

        private async void btnAnimation_Click(object sender, EventArgs e)
        {
            if (!animationInProgress)
                await Task.Run(() => Animation());
        }

        private void btnLoadNormalMap_Click(object sender, EventArgs e)
        {
            importing = true;
            if (!animationInProgress)
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    dialog.Filter = "Image Files|*.jpg;*.png";
                    dialog.FilterIndex = 2;
                    dialog.RestoreDirectory = true;
                    dialog.Multiselect = true;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        for (var i = 0; i < dialog.FileNames.Length; i++)
                        {
                            _normalMap[i] = new Bitmap(Image.FromFile(dialog.FileNames[i]));
                            _filler[i]._normalMap = new Bitmap(
                                _normalMap[i],
                                new Size(_bitmap[i].Width, _bitmap[i].Height)
                            );
                        }
                        DrawObject();
                    }
                }
            }
            importing = false;
        }

        private void rbHeightMapTrue_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < _bitmap.Count; i++)
            {
                _filler[i].heightMap = ((RadioButton)sender).Checked;
            }
            this.isHeightMapEnabled = ((RadioButton)sender).Checked;
        }

        private void sbRotationX_Scroll(object sender, ScrollEventArgs e)
        {
            rotationX[currentObject] = (float)(e.NewValue * 3.14 / 100);
            //for (var i = 0; i < transforms.Count; i++)
            transforms[currentObject][0] = Matrix4x4.CreateRotationX(rotationX[currentObject]);
            DrawObject();
        }

        private void sbRotationY_Scroll(object sender, ScrollEventArgs e)
        {
            rotationY[currentObject] = (float)(e.NewValue * 3.14 / 100);
            //for (var i = 0; i < transforms.Count; i++)
            transforms[currentObject][1] = Matrix4x4.CreateRotationY(rotationY[currentObject]);
            DrawObject();
        }

        private void sbRotationZ_Scroll(object sender, ScrollEventArgs e)
        {
            rotationZ[currentObject] = (float)(e.NewValue * 3.14 / 100);
            //for (var i = 0; i < transforms.Count; i++)
            transforms[currentObject][2] = Matrix4x4.CreateRotationX(rotationZ[currentObject]);
            DrawObject();
        }

        private void hScrollBar5_Scroll(object sender, ScrollEventArgs e)
        {
            cameraPosition[currentObject].X = (float)(e.NewValue - 50) / 10;
            //for (var i = 0; i < transforms.Count; i++)
            transforms[currentObject][3] = Matrix4x4.CreateLookAt(
                new Vector3(
                    cameraPosition[currentObject].X,
                    cameraPosition[currentObject].Y,
                    cameraPosition[currentObject].Z
                ),
                new Vector3(1, 1, 1),
                new Vector3(0, 0, 1)
            );
            DrawObject();
        }

        private void sbCameraPositionY_Scroll(object sender, ScrollEventArgs e)
        {
            cameraPosition[currentObject].Y = (float)(e.NewValue - 50) / 10;
            //for (var i = 0; i < transforms.Count; i++)
            transforms[currentObject][3] = Matrix4x4.CreateLookAt(
                new Vector3(
                    cameraPosition[currentObject].X,
                    cameraPosition[currentObject].Y,
                    cameraPosition[currentObject].Z
                ),
                new Vector3(1, 1, 1),
                new Vector3(0, 0, 1)
            );
            DrawObject();
        }

        private void sbCameraPositionZ_Scroll(object sender, ScrollEventArgs e)
        {
            cameraPosition[currentObject].Z = (float)(e.NewValue - 50) / 10;
            //for (var i = 0; i < transforms.Count; i++)
            transforms[currentObject][3] = Matrix4x4.CreateLookAt(
                new Vector3(
                    cameraPosition[currentObject].X,
                    cameraPosition[currentObject].Y,
                    cameraPosition[currentObject].Z
                ),
                new Vector3(1, 1, 1),
                new Vector3(0, 0, 1)
            );
            DrawObject();
        }

        private void sbEValue_Scroll(object sender, ScrollEventArgs ev)
        {
            e[currentObject] = (float)ev.NewValue / 50;
            //for (var i = 0; i < transforms.Count; i++)
            transforms[currentObject][4] = Matrix4x4.CreatePerspectiveFieldOfView(
                e[currentObject],
                a[currentObject],
                n[currentObject],
                f[currentObject]
            );
            DrawObject();
        }

        private void sbAValue_Scroll(object sender, ScrollEventArgs ev)
        {
            a[currentObject] = (float)ev.NewValue / 50;
            //for (var i = 0; i < transforms.Count; i++)
            transforms[currentObject][4] = Matrix4x4.CreatePerspectiveFieldOfView(
                e[currentObject],
                a[currentObject],
                n[currentObject],
                f[currentObject]
            );
            DrawObject();
        }

        private void sbNValue_Scroll(object sender, ScrollEventArgs ev)
        {
            n[currentObject] = (float)ev.NewValue / 300;
            //for (var i = 0; i < transforms.Count; i++)
            if (n[currentObject] < f[currentObject])
                transforms[currentObject][4] = Matrix4x4.CreatePerspectiveFieldOfView(
                    e[currentObject],
                    a[currentObject],
                    n[currentObject],
                    f[currentObject]
                );
            DrawObject();
        }

        private void sbFValue_Scroll(object sender, ScrollEventArgs ev)
        {
            f[currentObject] = (float)ev.NewValue / 150;
            //for (var i = 0; i < transforms.Count; i++)
            if (f[currentObject] > n[currentObject])
                transforms[currentObject][4] = Matrix4x4.CreatePerspectiveFieldOfView(
                    e[currentObject],
                    a[currentObject],
                    n[currentObject],
                    f[currentObject]
                );
            DrawObject();
        }

        private void rbObject1_CheckedChanged(object sender, EventArgs e)
        {
            if (_loadedObject.Count > ((RadioButton)sender).Name.Last() - '0' - 1)
                currentObject = ((RadioButton)sender).Name.Last() - '0' - 1;
        }
    }
}
